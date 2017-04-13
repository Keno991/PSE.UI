using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace PSE.Web.Api.Configuration
{
    //TODO: Test this, this is obsolete since I am using Autofac for injecting wcf services
    [Obsolete("Autofac takes care of injecting wcf services", false)]
    public class WcfServiceConfiguration<TService>: IDisposable
    {

        private ChannelFactory<TService> _factory;

        public TService service { get; set; }

        /// <summary>
        /// Creates channel to provided wcf service
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public void CreateWcfChannelForService(string url)
        {
            try
            {
                BasicHttpBinding myBinding = new BasicHttpBinding();
                EndpointAddress myEndpoint = new EndpointAddress(url);

                _factory = new ChannelFactory<TService>(myBinding, myEndpoint);

                // Create a channel.
                service = _factory.CreateChannel();
            }
            catch(Exception e) when(url == null) {
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _factory.Close();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
