using System;

namespace cpp2cs
{
    class FaitAccount : Account
    {
        public FaitAccount(int _id, String _name, double _balance)
            : base(_id, _name, _balance + _balance * 0.01)
        { }

        public override void AddMoney(double val)
        {
            base.AddMoney(val + val * 0.01);
        }
    }
}
