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
        public List<Member> GetMembers();

        public Member GetMember(int id);

        public Member getMemberByEmail(string email);

        public void updateMember(Member member);

        public void deleteMember(int memberId);

        public void addMember(Member member);
    }
}
