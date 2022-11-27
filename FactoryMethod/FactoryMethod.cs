// 크리에이터 클래스는 제품 클래스의 객체를 반환해야 하는 팩토리 메서드를
// 선언합니다. 크리에이터의 자식 클래스들은 일반적으로 이 메서드의 구현을
// 제공합니다.
class Dialog is
    // 크리에이터는 팩토리 메서드의 일부 디폴트 구현을 제공할 수도 있습니다.
    abstract method createButton():Button

    // 크리에이터의 주 업무는 제품을 생성하는 것이 아닙니다. 크리에이터는
    // 일반적으로 팩토리 메서드에서 반환된 제품 객체에 의존하는 어떤 핵심
    // 비즈니스 로직을 포함합니다. 자식 클래스들은 팩토리 메서드를 오버라이드 한
    // 후 해당 메서드에서 다른 유형의 제품을 반환하여 해당 비즈니스 로직을
    // 간접적으로 변경할 수 있습니다.
    method render() is
        // 팩토리 메서드를 호출하여 제품 객체를 생성하세요.
        Button okButton = createButton()
        // 이제 제품을 사용하세요.
        okButton.onClick(closeDialog)
        okButton.render()


// 구상 크리에이터들은 결과 제품들의 유형을 변경하기 위해 팩토리 메서드를
// 오버라이드합니다.
class WindowsDialog extends Dialog is
    method createButton():Button is
        return new WindowsButton()

class WebDialog extends Dialog is
    method createButton():Button is
        return new HTMLButton()


// 제품 인터페이스는 모든 구상 제품들이 구현해야 하는 작업들을 선언합니다.
interface Button is
    method render()
    method onClick(f)

// 구상 제품들은 제품 인터페이스의 다양한 구현을 제공합니다.
class WindowsButton implements Button is
    method render(a, b) is
        // 버튼을 윈도우 스타일로 렌더링하세요.
    method onClick(f) is
        // 네이티브 운영체제 클릭 이벤트를 바인딩하세요.

class HTMLButton implements Button is
    method render(a, b) is
        // 버튼의 HTML 표현을 반환하세요.
    method onClick(f) is
        // 웹 브라우저 클릭 이벤트를 바인딩하세요.


class Application is
    field dialog: Dialog

    // 앱은 현재 설정 또는 환경 설정에 따라 크리에이터의 유형을 선택합니다.
    method initialize() is
        config = readApplicationConfigFile()

        if (config.OS == "Windows") then
            dialog = new WindowsDialog()
        else if (config.OS == "Web") then
            dialog = new WebDialog()
        else
            throw new Exception("Error! Unknown operating system.")

    // 클라이언트 코드는 비록 구상 크리에이터의 기초 인터페이스를 통하는 것이긴
    // 하지만 구상 크리에이터의 인스턴스와 함께 작동합니다. 클라이언트가
    // 크리에이터의 기초 인터페이스를 통해 크리에이터와 계속 작업하는 한 모든
    // 크리에이터의 자식 클래스를 클라이언트에 전달할 수 있습니다.
    method main() is
        this.initialize()
        dialog.render()
