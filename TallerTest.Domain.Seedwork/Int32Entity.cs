using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TallerTest.Domain.Seedwork
{
    public class Int32Entity : Entity<int>
    {
        private int _id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id
        {
            get { return _id; }
            set
            {
                if (!this.IsTransient())
                {
                    throw new InvalidOperationException();
                }

                _id = value;
            }
        }


        public override bool IsTransient()
        {
            return this.Id == 0;
        }
    }


}
