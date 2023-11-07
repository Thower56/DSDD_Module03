//using M03_DAL_Municipalite;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Storage;

//namespace M03_API_Municipalite.Data
//{
//    public class ApplicationDbContext : IdentityDbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        private IDbContextTransaction? m_transaction;
//        public DbSet<MunicipaliteDTO>? MUNICIPALITES { get; set; }

//        public void BeginTransaction()
//        {
//            if (this.m_transaction is not null)
//            {
//                throw new InvalidOperationException("Une transaction est deja debutee");
//            }
//        }
//        public void Commit()
//        {
//            if (this.m_transaction is null)
//            {
//                throw new InvalidOperationException("Une transaction doit être débutée");
//            }
//            this.m_transaction.Commit();
//            this.m_transaction?.Dispose();
//            this.m_transaction = null;
//        }

//        public void Rollback()
//        {
//            if (this.m_transaction is null)
//            {
//                throw new InvalidOperationException("Une transaction doit être débutée");
//            }
//            this.m_transaction.Rollback();
//            this.m_transaction?.Dispose();
//            this.m_transaction = null;
//        }

//        public override void Dispose()
//        {
//            this.m_transaction?.Dispose();
//            this.m_transaction = null;
//            base.Dispose();
//        }
//    }
//}