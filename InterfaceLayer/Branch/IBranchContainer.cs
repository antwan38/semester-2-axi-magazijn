using System.Collections.Generic;

namespace DataAccessLayer;

public interface IBranchContainer
{ 
    List<BranchDTO> GetAll(); 
    BranchDTO Get(int id);
}