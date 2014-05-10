﻿/*  
 * Papercut
 *
 *  Copyright © 2008 - 2012 Ken Robertson
 *  Copyright © 2013 - 2014 Jaben Cargman
 *  
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *  http://www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *  
 */

namespace Papercut.Service
{
    using Autofac;

    using Papercut.Core;
    using Papercut.Core.Server;

    public class PapercutServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SmtpProtocol>()
                .Keyed<IProtocol>(ServerProtocolType.Smtp)
                .InstancePerDependency();

            builder.RegisterType<ConnectionManager>().AsSelf().InstancePerDependency();
            builder.RegisterType<Connection>().As<IConnection>().InstancePerDependency();
            builder.RegisterType<Server>().As<IServer>().InstancePerDependency();

            builder.RegisterType<PapercutService>().SingleInstance();
        }
    }
}