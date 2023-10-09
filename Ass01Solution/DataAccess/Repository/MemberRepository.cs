using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {

        public void AddMember(MemberObject member) => MemberDAO.Instance.AddMember(member);

        public void DeleteMember(int id) => MemberDAO.Instance.DeleteMember(id);

        public MemberObject GetMemberById(int id) => MemberDAO.Instance.GetMemberByID(id);

        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMembers;

        public void UpdateMember(MemberObject member) => MemberDAO.Instance.UpdateMember(member);

        public List<MemberObject> findMembersByName(String name) => MemberDAO.Instance.FindMembersByName(name);

        public MemberObject GetMemberByEmail(String email) => MemberDAO.Instance.FindMembersByEmail(email);

    }
}
