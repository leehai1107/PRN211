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
        public List<Member> GetMembers() => MemberDAO.Instance.GetMembers();

        public Member GetMember(int id) => MemberDAO.Instance.GetMemberById(id);

        public Member getMemberByEmail(string email) => MemberDAO.Instance.getMemberByEmail(email);

        public void updateMember(Member member) => MemberDAO.Instance.updateMember(member);

        public void deleteMember(int memberId) => MemberDAO.Instance.removeMember(memberId);

        public void addMember(Member member) => MemberDAO.Instance.addMember(member);

    }
}
