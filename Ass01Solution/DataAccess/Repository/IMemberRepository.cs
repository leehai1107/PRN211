using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberById(int id);
        void DeleteMember(int id);
        void UpdateMember(MemberObject member);
        void AddMember(MemberObject member);
        List<MemberObject> findMembersByName(string name);
        MemberObject GetMemberByEmail(String email);
    }
}
