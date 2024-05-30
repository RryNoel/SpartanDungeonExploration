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
- Framework : .NET 6.0

# 📌 주요 기술

## Input System

![Animation](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/8219589c-5ee5-4b23-a008-8898e51389ff)
![InvokeUnityEvents](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/c75d1d92-2c75-4246-a26c-f950f84f602b)

인풋 시스템을 활용해서 플레이어의 움직임을 구현, Invoke Unity 이벤트 사용

## Health Bar, DamageIndicator

![damageIndicator](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/89d05865-78bb-49f9-9f05-ba6ace05ec56)
![stamina](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/83cae187-f819-470f-bccc-7852a1de836f)

강의를 바탕으로 체력바, 배고픔 수치, 스태미너 UI 구현

## Rigidbody ForceMode, Ray, Raycast

![JumpPad](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/db7f4b3b-f150-4e8f-a26d-62ca943af541)
![raycast](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/64ecc927-a81f-45bc-a9d6-9355aba441ae)


리지디바디 포스모드를 사용해서 플레이어의 점프와 점프대를 구현   
레이와 레이케스트를 이용해서 땅에 닿아 있을 때만 점프할 수 있게 구현   
아이템의 정보를 Ray와 Raycast를 활용해서 UI에 아이템 정보를 표시

## Inventory and Item, ScriptableObject

![inventory](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/eab95a34-2f3d-42d8-a22a-59e3b8daa4bb)
![scriptableObject](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/b7a7184b-e383-4cfc-ac66-ac241c49c77c)

강의 내용을 바탕으로 스크립터블 오브젝트를 이용해서 아이템 관리   
곡괭이 아이템과 스피드 포션 아이템 추가

## Coroutine

![coroutine](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/3fd2c963-d088-4d5f-86b4-59cd36e347e8)
![coroutine2](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/c21a5a6e-e26b-482b-bfd0-0c19c39dbfce)

스피드 증가 아이템과 대쉬 기능을 코루틴으로 구현

# 📌 선택 기능 정리

## 추가 UI

### UI 디자인 업데이트

![UIDesign](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/98640bc2-d0f8-45d1-984d-1a63c8aca225)

### 포션 사용시 왼쪽 하단에 오버레이 등장

![potionUI](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/3c597052-6ad6-47fe-bec9-c42ed23a2697)

### 대쉬시 스태미나 감소

![run](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/0f5068f7-86b0-4174-8399-7635bd6cc843)

## 3인칭 카메라 시점

### F5를 누르게 되면 3인칭 카메라로 체인지

![image](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/25715af1-9879-4904-b946-4d420a2706be)

## 움직이는 플랫폼

![platform](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/b1af1ef1-e3ee-4525-afe5-b51a76323170)


# ⚒️ 트러블 슈팅

![AssetMissing](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/a0495bb5-330b-4c01-b871-6db5e978b9a9)
![githubError](https://github.com/RryNoel/SpartanDungeonExploration/assets/97824309/45dee6f1-e675-4c6e-88bb-ee429eda031b)

에셋과 gitignore에 관련해서 여러가지 오류 및 에셋 누락이 발생   
해결 방안으로는 에셋을 다시 import해서 해결함.

# 📌 에셋 정보

## 무료 에셋
City People Lite

## 유료 에셋
Survival Engine
