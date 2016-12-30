﻿using Nancy;

namespace KQAnalytics3.Modules
{
    public class KQBaseModule : NancyModule
    {
        public KQBaseModule(string path) : base(KQRegistry.KQBasePath + path)
        {
        }

        public KQBaseModule() : base(KQRegistry.KQBasePath)
        {
        }
    }
}