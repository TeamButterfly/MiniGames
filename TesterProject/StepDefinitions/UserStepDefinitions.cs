using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using Moq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TesterProject.StepDefinitions
{
    [Binding]
    public class UserStepDefinitions : AutoMockObject
    {
        private readonly IUserRepository _userRepository;

        private List<User> users = new List<User>();
        private User user;
        private bool isUserCreated;
        private bool isUserUpdated;
        private Guid userId;

        public UserStepDefinitions()
        {
            var fakeUser1 = new User() { UserId = Guid.NewGuid(), Username = "eteller", Password = "andet"};
            var fakeUser2 = new User() { UserId = Guid.NewGuid(), Username = "noneksistente", Password = "faker" };
            var fakeUsers = new List<User>();
            fakeUsers.Add(fakeUser1);
            fakeUsers.Add(fakeUser2);

            Register<IUserRepository>(mock =>
            {
                mock.Setup(framework => framework.GetUsers()).Returns(fakeUsers);
                mock.Setup(framework => framework.GetUser(It.IsAny<Guid>())).Returns(fakeUser1);
                mock.Setup(framework => framework.CreateUser(It.IsAny<User>())).Returns(true);
                mock.Setup(framework => framework.UpdateUser(It.IsAny<User>())).Returns(true);
            });

            _userRepository = Resolve<IUserRepository>();
        }

        [Given(@"I select all valid users")]
        public void GivenISelectAllValidUsers()
        {
            //Implicit er alle brugere valgt
        }
        [When(@"I click the see all user button")]
        public void WhenIClickTheSeeAllUserButton()
        {
            users = _userRepository.GetUsers();
        }
        [Then(@"I get all the users returned")]
        public void ThenIGetAllTheUsersReturned()
        {
            Assert.IsNotEmpty(users);
        }

        [Given(@"I select a valid user")]
        public void GivenISelectAValidUser()
        {
            var users = _userRepository.GetUsers();
            userId = users.First().UserId;
        }
        [When(@"I click the get information about the user button")]
        public void WhenIClickTheGetInformationAboutTheUserButton()
        {
            user = _userRepository.GetUser(userId);
        }
        [Then(@"I get the user information returned")]
        public void ThenIGetTheUserInformationReturned()
        {
            Assert.IsNotNull(user);
        }

        [Given(@"I am a new user")]
        public void GivenICreateANewUser()
        {
            user = new User { Username = "Hanne", Password = "kat!123" };
        }
        [Given(@"I submit valid data")]
        public void GivenISubmitValidData()
        {
            _userRepository.ValidateUser(user);
        }
        [When(@"I click the create user button")]
        public void WhenIClickTheCreateUserButton()
        {
            isUserCreated = _userRepository.CreateUser(user);
        }
        [Then(@"The user is successfully created")]
        public void ThenTheUserIsSuccessfullyCreated()
        {
            Assert.IsTrue(isUserCreated);
        }
        [Given(@"I am an existing user")]
        public void GivenIUpdateAnExistingUser()
        {
            var users = _userRepository.GetUsers();
            user = new User { UserId = users.First().UserId, Username = "Ole", Password = "blah!123" };
        }
        [When(@"I click the update user button")]
        public void WhenIClickTheUpdateUserButton()
        {
            isUserUpdated = _userRepository.UpdateUser(user);
        }
        [Then(@"The user is successfully updated")]
        public void ThenTheUserIsSuccessfullyUpdated()
        {
            Assert.IsTrue(isUserUpdated);
        }
    }
}
