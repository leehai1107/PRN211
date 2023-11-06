using BussinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        MemberDAO memberDAO = new MemberDAO();

        public List<Member> GetMembers() => memberDAO.GetMembers();

        public Member GetMember(int id) => memberDAO.GetMember(id);

        public void AddMember(Member member) => memberDAO.AddMember(member);

        public void UpdateMember(Member member) => memberDAO.UpdateMember(member);

        public void DeleteMember(int id) => memberDAO.DeleteMember(id);

        public Member GetMemberByEmail(string email) => memberDAO.GetMemberByEmail(email);
    }
}
