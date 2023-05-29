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
---

<!-- https://gist.github.com/rxaviers/7360908 -->

<style scoped>section { text-align: center } </style> 


![w:250](assets/dotnet_bot.svg)

# .NET MAUI
#### Object Oriented Patterns in Cross Platform Development

---

# What is .NET MAUI

---

![bg w:80%](assets/architecture.png)

---
## Model View View-Model

- Architectural pattern
- Divides the architecture in **three** main components
  - **Model** (described using POCO classes)
  - **View Model** (where the business logic resides)
  - **View** (where the GUI is declared)
- The framework provides various way to **decouple** the View from the View-Model

![w:1920 h:250 center](assets/mvvm.drawio.svg)

---

https://gist.github.com/rxaviers/7360908

