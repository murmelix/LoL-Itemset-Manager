﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lol.Api.Toolkit
{
    public abstract class WcfServiceClient<TClient> : ClientBase<TClient>, IDisposable where TClient : class
    {
        internal WcfServiceClient() { }

        internal WcfServiceClient(string endpointConfigurationName) : base(endpointConfigurationName) { }

        internal WcfServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

        internal WcfServiceClient(InstanceContext callbackInstance) : base(callbackInstance) { }

        public TClient Instance
        {
            get { return base.Channel; }
        }

        public event EventHandler<GenericAsyncCompletedEventArgs> AsyncCompleted;

        public void AsyncBegin(string methodName, object userState, params object[] inValues)
        {
            Console.WriteLine("AsyncBegin thread: {0}", Thread.CurrentThread.ManagedThreadId);
            if (string.IsNullOrEmpty(methodName)) throw new NullReferenceException("methodName cannot be null");
            MethodInfo mi = this.Instance.GetType().GetMethod(methodName);
            if (null != mi)
            {
                Func<MethodInfo, object[], object> func = new Func<MethodInfo, object[], object>(this.ExecuteAsyncMethod);
                func.BeginInvoke(mi, inValues, new AsyncCallback(this.FuncCallback), new GenericAsyncState() { UserState = userState, MethodName = methodName, InValues = inValues });
            }
            else
                throw new TargetException(string.Format("methodName {0} not found on instance", methodName));
        }

        private object ExecuteAsyncMethod(MethodInfo mi, object[] inValues)
        {
            return mi.Invoke(this.Instance, inValues);
        }

        private void FuncCallback(IAsyncResult result)
        {
            Console.WriteLine("FuncCallback thread: {0}", Thread.CurrentThread.ManagedThreadId);
            var deleg = (Func<MethodInfo, object[], object>)((AsyncResult)result).AsyncDelegate;
            var state = result.AsyncState as GenericAsyncState;
            if (null != deleg)
            {
                Exception error = null;
                object retval = null;
                try
                {
                    retval = deleg.EndInvoke(result);
                }
                catch (Exception e)
                {
                    error = e;
                }
                object userState = state == null ? null : state.UserState;
                string methodName = state == null ? (string)null : state.MethodName;
                object[] inValues = state == null ? null : state.InValues;
                GenericAsyncCompletedEventArgs args = new GenericAsyncCompletedEventArgs(retval, error, methodName, userState, inValues);
                if (this.AsyncCompleted != null)
                    this.AsyncCompleted(this, args);
            }
        }

        public void Dispose()
        {
            AbortClose();
        }

        public void AbortClose()
        {
            //avoid the CommunicationObjectFaultedException 
            if (this.State != CommunicationState.Closed) this.Abort();
            //safe to close the client
            this.Close();
        }

        private class GenericAsyncState
        {
            public object UserState { get; set; }
            public string MethodName { get; set; }
            public object[] InValues { get; set; }
        }
    }

    public class GenericAsyncCompletedEventArgs : EventArgs
    {
        public GenericAsyncCompletedEventArgs(object result, Exception error, string methodName, object userState, object[] inValues)
        {
            this.Result = result;
            this.Error = error;
            this.MethodName = methodName;
            this.UserState = userState;
            this.InValues = inValues;
        }
        public object Result { get; private set; }
        public Exception Error { get; private set; }
        public string MethodName { get; private set; }
        public object UserState { get; private set; }
        public object[] InValues { get; private set; }
    }    
}
