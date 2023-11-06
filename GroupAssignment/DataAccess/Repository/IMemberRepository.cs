using BussinessObjects.Models;
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
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public void DeleteMember(int id);
        public Member GetMemberByEmail(string email);
    }
}
