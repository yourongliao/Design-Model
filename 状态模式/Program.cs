using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();       //先初始化一个拥有者Context的对象

            context.SetState(new ConcreteStateA(context));  //通过调用SetState()的方法

            context.Handle(5);  //默认是状态A，所以输出 状态A，而且5>10,下一级还是输出 状态A
            context.Handle(20); //输出 状态A，但是20>10,下一级输出 状态B
            context.Handle(30); //输出 状态B，而且30>10,下一级输出 状态B
            context.Handle(4); //输出 状态B，但是4<10,下一级输出 状态A
            context.Handle(1);//输出 状态A，而且1<10,下一级输出 状态A

            Console.ReadKey();
        }                                                   
    }                                                       



    public class Context    //这是状态的拥有者
    {
        private IState mState;  //私有的状态对象

        public void SetState(IState state)  //公有的SetState()方法，便于其他类，去传递状态
        {
            mState = state;
        }

        public void Handle(int arg)//在状态的拥有者里面，定义一个Handle()方法，
                                   //去调用状态A或者状态B里面的Handle()方法
        {
            mState.Handle(arg);
        }
    }

    public interface IState     //这是状态的接口
    {
        void Handle(int arg);
    }

    public class ConcreteStateA : IState
    {

        private Context mContext;       //定义一个私有的Context对象

        public ConcreteStateA(Context context)  //然后通过构造方法，就可以确认
        {
            mContext = context;                 //被调用的实现子类，是隶属于，哪个Context拥有者的
        }

        public void Handle(int arg)
        {
            Console.WriteLine("如果数值小于或等于10，状态A打印为" + arg);

            if (arg > 10)
            {
                //设定为，如果传递的数值，大于10的话，就转换到状态B

                mContext.SetState(new ConcreteStateB(mContext));
            }
        }
    }

    public class ConcreteStateB : IState
    {
        private Context mContext;       //定义一个私有的Context对象

        public ConcreteStateB(Context context) //然后通过构造方法，就可以确认
        {
            mContext = context;                //被调用的实现子类，是隶属于，哪个Context拥有者的
        }

        public void Handle(int arg)
        {
            Console.WriteLine("如果数值大于10，状态B打印为" + arg);


            if (arg <= 10)
            {
                //设定为，如果传递的数值，小于或10的话，就转换到状态A
                mContext.SetState(new ConcreteStateA(mContext));
            }
        }

    }
}
