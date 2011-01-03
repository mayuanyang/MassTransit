// Copyright 2007-2011 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Transports.RabbitMq
{
    using System;
    using MassTransit.Configuration;

    public class RabbitMqEndpointFactory :
        IEndpointFactory
    {
        public IEndpoint ConfigureEndpoint(Uri uri, Action<IEndpointConfigurator> configurator)
        {
            if (uri.Scheme.ToLowerInvariant() == "rabbitmq")
            {
                var cfg = new RabbitMqEndpointConfigurator();
                IEndpoint endpoint = cfg.New(x =>
                {
                    x.SetUri(uri);

                    configurator(x);
                });

                return endpoint;
            }

            return null;
        }
    }
}