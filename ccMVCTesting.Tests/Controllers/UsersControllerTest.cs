using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ccMVCTesting.Model;
using ccMVCTesting.Controllers;
using ccMVCTesting.Repository.MockRepository;

namespace ccMVCTesting.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        #region "Auxiliary"

        private TestUsersRepository _repository;
        private UsersController _controller;
        private int _lastUsedId = 0;
        private const int INITIAL_TEST_RECORDS = 5;
        private User _usr;
        private List<User> beforeData;

        //
        private User GenerateOneTestUserData()
        {
            User usr = new User();
            //
            usr.Created = new DateTimeOffset(DateTime.Now);
            usr.OriginalEMail = "patito." + usr.Created.Millisecond.ToString() + "_" +
                                            usr.Created.Second.ToString() + "_" + 
                                            usr.Created.Minute.ToString() + "_" + 
                                            usr.Created.Hour.ToString() + 
                                            "@patita.com";
            usr.OriginalPwd = "oPwd." + usr.Created.Second.ToString();
            //
            usr.Active = true;
            usr.Confirmed = usr.Created;
            usr.CurrentEMail = usr.OriginalEMail;
            usr.CurrentPwd = usr.OriginalPwd;
            usr.FailedAttempts = 0;
            usr.LastUpdated = usr.Created;
            //
            usr.AuthUserID = Guid.NewGuid().ToString();
            usr.UserID = ++_lastUsedId;
            //
            return usr;
            //
        } // GenerateOneTestUserData

        //
        private List<User> GetTestListFromActionIndex()
        {
            var indexResult = (ViewResult)_controller.Index();
            return (List<User>)indexResult.ViewData.Model;
            //
        } // GetTestListFromActionIndex

        // setup any resources need by tests on this Test class
        // 1. create Test repository object
        // 2. create Test controller object (this is what will be tested)
        // 3. generate set of test records, if requested by param GenerateTestRecords
        // 4. generate a separated test record if requested by param GenerateExtraTestRecord
        // 5. call to controller to return a list of records from repository
        private void SetupUsersTestResources(bool GenerateTestRecords = true, bool GenerateExtraTestRecord = false)
        {
            _repository = new TestUsersRepository();
            _controller = new UsersController(_repository);
            //
            if (GenerateTestRecords)
                _lastUsedId = _repository.CreateTestData(0, INITIAL_TEST_RECORDS);
            //
            if(GenerateExtraTestRecord)
                _usr = GenerateOneTestUserData();
            //
            beforeData = GetTestListFromActionIndex();
            //
        } // SetupUsersTestResources

        #endregion

        #region "Already tested and Passed"

        [TestMethod]
        [Description("Check that Users/Index doesn't return data when there are no Users in db")]
        public void IndexWithoutData()
        {
            // Arrange
            SetupUsersTestResources(false,false);

            // Act
            // already done ==> beforeData

            // Assert
            Assert.IsFalse(beforeData.Any(), "Data was returned, but NONE was expected");
            //
        } // IndexWithoutData

        [TestMethod]
        [Description("Check that Users/Index returns data")]
        public void IndexWithData()
        {
            // Arrange
            SetupUsersTestResources(true,false);

            // Act
            // already done ==> beforeData

            // Assert
            Assert.IsTrue(beforeData.Any(), "No data was returned, but SOME was expected");
            //
        } // IndexWithData

        [TestMethod]
        [Description("Create one record")]
        public void Create()
        {
            bool r = false;

            // Arrange
            SetupUsersTestResources(true,true);

            // Act
            var partial = (RedirectToRouteResult)_controller.Create(_usr);

            // Assert
            if (null != partial)
            {
                // ... get updated list
                List<User> afterData = GetTestListFromActionIndex();

                // ... compare result
                if (afterData.Count == (beforeData.Count + 1))
                    r = true;
                //
            }
            //
            Assert.IsTrue(r, "Test data was not added");
            //
        } // Create

        [TestMethod]
        [Description("Delete an existing record")]
        public void Delete()
        {
            bool r = false;

            // Arrange
            SetupUsersTestResources(true,false);

            // Act
            var deleteresult = (ActionResult)_controller.DeleteConfirmed(_lastUsedId);

            // Assert
            if (null != deleteresult)
            {
                List<User> afterData = GetTestListFromActionIndex();
                if (afterData.Count == (beforeData.Count - 1))
                    r = true;
            }
            //
            Assert.IsTrue(r, "Test data was not deleted");
            //
        } // Delete

        #endregion

    } // class

} // namespace
