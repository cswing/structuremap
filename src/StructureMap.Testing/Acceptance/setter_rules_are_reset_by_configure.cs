﻿using Shouldly;
using Xunit;

namespace StructureMap.Testing.Acceptance
{
    public class setter_rules_are_reset_by_configure
    {
        [Fact]
        public void build_plans_are_reset()
        {
            var container = new Container();

            // Not a property that would be set
            // by default
            container.GetInstance<GuyWithWidget>()
                .Widget.ShouldBeNull();

            container.Configure(x => { x.Policies.FillAllPropertiesOfType<IWidget>().Use<AWidget>(); });

            container.GetInstance<GuyWithWidget>()
                .Widget.ShouldBeOfType<AWidget>();
        }
    }

    public class GuyWithWidget
    {
        public IWidget Widget { get; set; }
    }
}