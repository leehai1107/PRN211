using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        public List<Member> GetMembers()
        {
            using(DemoContext context = new DemoContext())
            {
                return context.Members.Include(x => x.Role).ToList();
            }
        }

        public Member GetMember(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Members.Include(x => x.Role).SingleOrDefault(m => m.MemberId == id);
            }
        }

        public void AddMember(Member member)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Members.Add(member);
                context.SaveChanges();
            }
        }

        public void DeleteMember(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                Member member = GetMember(id);
                context.Members.Remove(member);
                context.SaveChanges();
            }
        }

        public void UpdateMember(Member member)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Members.Update(member);
                context.SaveChanges();
            }
        }

        public Member GetMemberByEmail(string email)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Members.SingleOrDefault(m => m.Email.Equals(email));
            }
        }
    }
}
