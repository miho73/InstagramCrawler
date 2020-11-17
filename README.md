# InstagramCrawler
**인스타그램의 한 프로필의 모든 사진을 크롤링 해옵니다.**

## 한국어/Korean
### 1. 기본 설명
 * 이 프로그램은 C#으로 작성되어 있습니다.
 * 본 레포지토리에는 2개의 프로젝트가 올라와 있으며 하나는 크롤링 시스템을 구현해놓은 DLL 동적 연결 라이브러리를 만드는 프로젝트이고 다른 하나는 이 라이브러리로 실제 크롤링을 수행하는 프로젝트입니다.
 * 소스코드에는 별도의 주석을 달지 않았습니다(제 기준에서 누구나 이해할 수 있기 때문에).
 * 컴파일된 바이너리파일을 올리지 않았습니다. 추후 고민한 후 올릴수 있으면 올리겠습니다. 바이너리파일이 꼭 필요하신 분은 직접 컴파일해서 쓰세요.
 * 로그인 과정이 필요 없는 과정인가 생각하고 있습니다. 사용자로부터 수집되는 개인정보는 최소화되는 것이 좋기 때문에 조금 더 테스트한 후 로그인 절차를 빼는 것도 생각해 보겠습니다.
### 2. 의존성
 * Selenium Webdriver - Apache License 2.0으로 허용되었습니다. [전문](http://www.apache.org/licenses/LICENSE-2.0)
 * ChromeDriver - Unlicensed로 허용되었습니다. [전문](https://licenses.nuget.org/Unlicense)
### 3. 추가 노트
 * [Instagram 크롤러 정책](https://www.instagram.com/robots.txt)을 참고하세요. 이 프로그램을 상식선 밖에서 써서는 안 됩니다.
 * 이 프로그램으로 과도한 요청을 보내거나 하는 등의 행동으로 불이익을 당해도 책임지지 않습니다.

---

## 영어/English
### 1. About
 * This program is written in C#
 * There're two projects in this repository. One is dll project which provide crawling system and the other is project that actually do crawling with dll binary.
 * There're no any comment in any code.
 * I did not pushed compiled binary file. If you need, I wish you to compile yourself. I considering to upload binary file.
 * After more test, I'll remove login step to reduce collected privacy from user.
### 2. 의존성
 * Selenium Webdriver - Apache License 2.0 [License](http://www.apache.org/licenses/LICENSE-2.0)
 * ChromeDriver - Unlicensed [License](https://licenses.nuget.org/Unlicense)
### 3. 추가 노트
 * Reference [Instagram 크롤러 정책](https://www.instagram.com/robots.txt). Don't use this program naughty.
 * I me myself don't have any responsibility of abuse of this program. Don't send too much traffic or any naughty thing with this program.
