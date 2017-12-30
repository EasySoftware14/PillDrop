﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace PillDropApplication
{
    public class StructureMapResolver : StructureMapDependencyScope, IDependencyResolver, IHttpControllerActivator
    {
        private readonly IContainer container;

        public StructureMapResolver(IContainer container)
            : base(container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;

            this.container.Inject(typeof(IHttpControllerActivator), this);
        }

        public IDependencyScope BeginScope()
        {
            return new StructureMapDependencyScope(container.GetNestedContainer());
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return container.GetNestedContainer().GetInstance(controllerType) as IHttpController;
        }
    }
}