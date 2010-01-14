using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Sample.Data.Generated.ManagerObjects;
using Sample.Data.Generated.BusinessObjects;
using Sample.Data.Generated.Base;

namespace Sample.Data.Generated.UnitTests
{
	[TestFixture]
    public partial class CategoryTests : UNuitTestBase
    {
        protected ICategoryManager manager;
		
		public CategoryTests()
        {
            manager = managerFactory.GetCategoryManager();
        }
		
		protected Category CreateNewCategory()
		{
			Category entity = new Category();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = "Te";
			
			entity.Name = "Test Te";
			entity.Descn = "Test Test ";
			
			return entity;
		}
		protected Category GetFirstCategory()
        {
            IList<Category> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				Category entity = CreateNewCategory();
				
                object result = manager.Save(entity);

                Assert.IsNotNull(result);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Read()
        {
            try
            {
                Category entityA = CreateNewCategory();
				manager.Save(entityA);

                Category entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA, entityB);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
		[Test]
		public void Update()
        {
            try
            {
                Category entityA = GetFirstCategory();
				
				entityA.Name = "Test Test Test Test Test Te";
				
				manager.Update(entityA);

                Category entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.Name, entityB.Name);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Delete()
        {
            try
            {
                Category entity = GetFirstCategory();
				
                manager.Delete(entity);

                entity = manager.GetById(entity.Id);
                Assert.IsNull(entity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
	}
}

