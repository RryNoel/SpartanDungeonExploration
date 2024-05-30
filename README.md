# SpartanDungeonExploration 스파르타 던전 탐험

유니티 숙련 개인 과제

# 🖥️ 프로젝트 소개

스파르타코딩클럽 내일배움캠프 - 게임 개발 숙련 개인 프로젝트

Unity를 활용한 3D 게임

# 🕰️ 개발 기간

24.05.24 (금) - 24.05.30 (목)

# 🧑‍🤝‍🧑 팀원 구성

- 김정석

# ⚙️ Development Environment

- Language : C#
- Engine : Unity 2022.3.17f1
- IDE : Visual Studio 2022
- Framework : .NET 8.0

# 📌 주요 기술

## Singleton

여러가지 필드와 자료들을 중복해서 생성하지 않고 여러 스크립트에서 공유하기위해 정적 객체를 활용.
CharacterManager를 싱글톤화 함으로써 다양한 스크립트에서 사용

## Input System

![Animation](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/8219589c-5ee5-4b23-a008-8898e51389ff)

인풋 시스템을 활용해서 플레이어의 움직임을 구현, Invoke Unity 이벤트 사용

## Health Bar, DamageIndicator

![damageIndicator](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/89d05865-78bb-49f9-9f05-ba6ace05ec56)
![stamina](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/83cae187-f819-470f-bccc-7852a1de836f)

강의를 바탕으로 체력바, 배고픔 수치, 스태미너 UI 구현

## Rigidbody ForceMode, Ray, Raycast

![jumpPad](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/9ed48903-6662-46d6-811a-d506f71c2344)
![raycast](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/64ecc927-a81f-45bc-a9d6-9355aba441ae)


리지디바디 포스모드를 사용해서 플레이어의 점프와 점프대를 구현
레이와 레이케스트를 이용해서 땅에 닿아 있을 때만 점프할 수 있게 구현
아이템의 정보를 Ray와 Raycast를 활용해서 UI에 아이템 정보를 표시

## Inventory and Item, ScriptableObject

![scriptableObject](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/b7a7184b-e383-4cfc-ac66-ac241c49c77c)
![inventory](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/eab95a34-2f3d-42d8-a22a-59e3b8daa4bb)

강의 내용을 바탕으로 스크립터블 오브젝트를 이용해서 아이템 관리
곡괭이 아이템과 스피드 포션 아이템 추가

## Couroutine

![coroutine](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/3fd2c963-d088-4d5f-86b4-59cd36e347e8)
![coroutine2](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/c21a5a6e-e26b-482b-bfd0-0c19c39dbfce)

스피드 증가 아이템과 대쉬 기능을 코루틴으로 구현


# ⚒️ 트러블 슈팅

![AssetMissing](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/a0495bb5-330b-4c01-b871-6db5e978b9a9)
![githubError](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/45dee6f1-e675-4c6e-88bb-ee429eda031b)

에셋과 gitignore에 관련해서 여러가지 오류 및 에셋 누락이 발생

해결 방안으로는 에셋을 다시 import해서 해결함.
