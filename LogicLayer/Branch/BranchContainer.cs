using System;
using System.Collections.Generic;
using DataAccessLayer;
using InterfaceLayer;

namespace LogicLayer
{
    public class BranchContainer
    {
        private IBranchContainer _IBranchContainer;

        public BranchContainer(IBranchContainer iBranchContainer)
        {
            _IBranchContainer = iBranchContainer;
        }

        public List<Branch> GetAll()
        {
            List<Branch> result = new List<Branch>();
            foreach (BranchDTO branch in _IBranchContainer.GetAll())
            {
                result.Add(new Branch(branch));
            }

            return result;
        }

        public Branch Get(int id)
        {
            BranchDTO dto = _IBranchContainer.Get(id);
            Branch branch = new Branch(dto);
            if (id == branch.ID)
            {
                return branch;
            }

            throw new NullReferenceException("Branch with given ID not present.");
        }
    }
}