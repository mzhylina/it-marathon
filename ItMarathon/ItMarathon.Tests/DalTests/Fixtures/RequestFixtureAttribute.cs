﻿using AutoFixture;
using ItMarathon.Dal.Context;
using ItMarathon.Dal.Entities;

namespace ItMarathon.Tests.DalTests.Fixtures;

public class RequestFixtureAttribute : BaseDataAttribute
{
    public RequestFixtureAttribute()
        : base(ConfigureFixture)
    {
    }

    private static void ConfigureFixture(IFixture fixture)
    {
        var dbContext = fixture.Create<ApplicationDbContext>();

        dbContext.Requests.AddRange(fixture.CreateMany<Request>(2));
        dbContext.SaveChanges();

        fixture.Inject(dbContext);
    }
}