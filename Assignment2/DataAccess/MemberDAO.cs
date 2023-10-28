using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() {  }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Member> GetMembers()
        {
           using(Assignment2Context context = new Assignment2Context())
            {
                return context.Members.ToList();
            }
        }

        public Member GetMemberById(int id)
        {
            using(Assignment2Context context =  new Assignment2Context())
            {
                return context.Members.SingleOrDefault(m => m.MemberId == id);
            }
        }

        public void removeMember(int id)
        {
            using(Assignment2Context context = new Assignment2Context())
            {
                Member member = GetMemberById(id);
                if (member != null)
                {
                    context.Members.Remove(member);
                    context.SaveChanges();
                }
            }
        }

        public void updateMember(Member memberdata)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                context.Members.Update(memberdata);
                context.SaveChanges();
            }
        }

        public void addMember(Member member)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                Member m = GetMemberById(member.MemberId);
                if(m==null)
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
        }

        public Member getMemberByEmail(string email)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return (Member)context.Members.SingleOrDefault(m => m.Email.Equals(email));
            }
        }
    }
}
