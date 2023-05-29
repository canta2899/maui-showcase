---
marp: true
theme: default 
class: invert
size: 16:9
paginate: true
style: |
  img {background-color: transparent!important;}
  a:hover, a:active, a:focus {text-decoration: none;}
  header a {color: #ffffff !important; font-size: 30px;}
  footer {color: #148ec8;}
  img[alt~="center"] {
    display: block;
    margin: 0 auto;
  }
  .columns {
    display: grid;
    grid-template-columns: repeat(2, minmax(0, 1fr));
    gap: 1rem;
  }
  .center {
    text-align: center;
  }
  .end {
    text-align: end;
  }
  .start {
    text-align: start;
  }
---

<!-- https://gist.github.com/rxaviers/7360908 -->

<!-- _footer: "<h2>Andrea Cantarutti <br/> A.A. 2022/2023 <br/></h2>" -->

<div class="center">

![w:250](assets/dotnet_bot.svg)

# .NET MAUI
#### Object Oriented Patterns in Cross Platform Development

</div>

---

# What is .NET MAUI

- A **Microsoft Framework** built on top of .NET
- Successor of Xamarin.Forms
- Allows for cross-platform development from a single **C#** code-base
- Provides a series of features such as:
  - A **layout engine**
  - **Multiplatform APIs**
  - **Hot Reload**


<div class="end">

_Write once, run everywhere_

</div>


---

![bg w:75%](assets/architecture.png)

---

---

## Model View View-Model

- Architectural pattern
- Divides the architecture in **three** main components
  - **Model** (described using POCO classes)
  - **View Model** (where the business logic resides)
  - **View** (where the GUI is declared)
- The framework provides various ways to **decouple** the View from the View-Model

![w:1920 h:250 center](assets/mvvm.drawio.svg)


