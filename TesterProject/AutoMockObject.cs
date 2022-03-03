using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterProject
{
    public abstract class AutoMockObject
    {
        private readonly IDictionary<Type, dynamic> _mocks;

        protected AutoMockObject()
        {
            _mocks = new Dictionary<Type, dynamic>();
        }

        public virtual void Register<TObject>(Action<Mock<TObject>> action) where TObject : class
        {
            var mockObject = new Mock<TObject>();
            _mocks.Add(typeof(TObject), mockObject);
            action(mockObject);
        }

        public virtual TObject? Resolve<TObject>() where TObject : class
        {
            dynamic mock;

            return !_mocks.TryGetValue(typeof(TObject), out mock) ? null : mock.Object;
        }
    }
}
