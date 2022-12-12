﻿//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using FluentAssertions;
using Moq;
using System.Linq;
using Tarteeb.Api.Models.Teams;
using Xunit;

namespace Tarteeb.Api.Tests.Unit.Services.Foundations.Teams
{
    public partial class TeamServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllTeams()
        {
            //given
            IQueryable<Team> randomTeams = CreateRandomTeam();
            IQueryable<Team> storageTeams = randomTeams;
            IQueryable<Team> expectedTeam = storageTeams;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllTeams()).Returns(storageTeams);

            //when
            IQueryable<Team> actualTeam = this.teamService.RetrieveAllTeams();

            //then
            actualTeam.Should().BeEquivalentTo(expectedTeam);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllTeams(), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}