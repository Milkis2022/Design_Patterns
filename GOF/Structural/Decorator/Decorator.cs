using System;

namespace DesignPatterns
{   
    // 추상 클래스 Component
    // 기본 기능을 하는 ConcreteComponent 와 추가 기능을 하는 Decorator의
    // 공통 기능을 정의함
    public abstract class Component
    {
        public abstract string Operation();
    }

    // 기본 기능을하는 클래스
    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    // 추가적인 기능을 하는 클래스
    abstract class Decorator : Component
    {
        protected Component _component;

        // 기본 생성자 Setter 정의
        public Decorator(Component component)
        {
            this._component = component;
        }
        public void SetComponent(Component component)
        {
            this._component = component;
        }

        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            return string.Empty;
        }

    }

    class ConcreteDecoratorA : Decorator
    {
        // Decorator 생성자 호출
        public ConcreteDecoratorA(Component comp) : base(comp)
        {

        }
        // base 클래스인 Decortator에서 오버라이딩 된 Operation을 호출
        public override string Operation()
        {   
            return $"ConcreteDecoratorA({base.Operation()})";
        }

    }
    class ConcreteDecoratorB : Decorator
    {   
        // Decorator 생성자 호출
        public ConcreteDecoratorB(Component comp) : base(comp)
        {

        }
        // base 클래스인 Decortator에서 오버라이딩 된 Operation을 호출
        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }

    }

    public class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine("ClientCode 호출 : " + component.Operation());
        }
    }



    class Program
    {
        static void Main(string[] args)
        {   
            // 클라이언트 객체 생성
            Client client = new Client();

            // 컴포넌트 생성
            var simple = new ConcreteComponent();
            Console.WriteLine("Client : 기본기능만을 가지고 있음");
            client.ClientCode(simple);
            
            
            Console.WriteLine("\n");


            // 데코레이터 생성
            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("데코레이터 장착 ");
            client.ClientCode(decorator2);
        }
    }
}
