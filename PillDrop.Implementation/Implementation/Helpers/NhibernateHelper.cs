﻿using NHibernate;
using NHibernate.Burrow;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public sealed class NHibernateHelper
    {
        public static ISession GetCurrentSession()
        {
            return new BurrowFramework().GetSession();
        }

        public static ISessionFactory GetCurrentSessionFactory()
        {
            return new BurrowFramework().GetSessionFactory("PersistenceUnit1");
        }
    }
}