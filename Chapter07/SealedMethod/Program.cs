using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Base
{
    public virtual void SealMe()
    {
    }
}

class Derived : Base
{
    public sealed override void SealMe()
    {
    }
}

class WantToOverride : Derived
{
    public override void SealMe()
       
    {
    }
}

class MainApp
{
    static void Main(string[] args)
    {
    }
}

//오작동 위험이 있거나, 잘못 오버라이딩함으로써 발생할 수 있는 문제가 예상된다면
// 이렇게 봉인 메소드를 이용해서 상속을 사전에 막는 것이 낫다.