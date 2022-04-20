using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TesterProject.StepDefinitions
{
    [Binding]
    public class UserStepDefinitions : AutoMockObject
    {
        private readonly IDatabaseConnection _databaseConnection;
        private readonly IUserRepository _userRepository;

        public UserStepDefinitions(IConfiguration configuration)
        {
            _databaseConnection = new DatabaseConnection(configuration);
            _userRepository = new UserRepository(_databaseConnection, isTest: true);

            var users = _userRepository.GetUsers();
            if(users.Count() > 15)
            {
                _userRepository.DeleteUsers(users.Select(x => x.UserId).ToList());
            }
        }

        private List<User> users = new List<User>();
        private User user;

        [Given(@"I select all valid users")]
        public void GivenISelectAllValidUsers()
        {
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
        }
        [When(@"I click the get information about the user button")]
        public void WhenIClickTheGetInformationAboutTheUserButton()
        {
            user = _userRepository.GetUser(_userRepository.GetUsers().First().UserId);
        }
        [Then(@"I get the user information returned")]
        public void ThenIGetTheUserInformationReturned()
        {
            Assert.IsNotNull(user);
        }

        [Given(@"I am a new user")]
        public void GivenICreateANewUser()
        {
            user = new User { Username = GenerateRandomString(8), Password = GenerateRandomString(8) };
        }
        [Given(@"I submit valid data")]
        public void GivenISubmitValidData()
        {
            _userRepository.ValidateUser(user);
        }
        [When(@"I click the create user button")]
        public void WhenIClickTheCreateUserButton()
        {
            Assert.IsTrue(_userRepository.CreateUser(user));
        }
        [Then(@"The user is successfully created")]
        public void ThenTheUserIsSuccessfullyCreated()
        {
            Assert.IsTrue(true);
        }

        [Given(@"I am an existing user")]
        public void GivenIUpdateAnExistingUser()
        {
            user = new User { UserId = _userRepository.GetUsers().First().UserId, Username = GenerateRandomString(8), Password = GenerateRandomString(8) };
        }
        [When(@"I click the update user button")]
        public void WhenIClickTheUpdateUserButton()
        {
            Assert.IsTrue(_userRepository.UpdateUser(user));
        }
        [Then(@"The user is successfully updated")]
        public void ThenTheUserIsSuccessfullyUpdated()
        {
            Assert.IsTrue(true);
        }

        private static Random random = new Random();
        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzæøåABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
