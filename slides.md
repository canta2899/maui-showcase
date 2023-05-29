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
  .filename {
    font-size: 0.7rem;
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

# :question: What is .NET MAUI

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

# :computer: Working with .NET MAUI

- The framework allows to organize development in various ways
- The codebase might easily become unmantainable and grow in complexity as the project evolves 
- We can curb that by applying **design** and **architectural** patterns
- As developers we should keep in mind:
  - Dependencies
  - Testability
  - Readability
  - ...

---

## Code that gives me anxiety :worried:

<div class="columns">
<div>

```cs

public class MainPage : ContentPage
{
  Button button;
  Label label;

  public MainPage()
  {
    InitializeComponent();
    button = new Button { Text = "Click Me!" };
    label = new Label() { TextType = "Html" };
    button.Clicked += OnButtonClicked;
  }

  private async void OnButtonClicked(object sender, EventArgs e)
  {
    using var httpClient = new();
    // setup the client...
    var response = await client.GetAsync("/api/posts");
    // deserialize response to a Post instance ...
    label.Text = post.ToHtml();
  }
}

```

</div>

<div style="margin-top: 80px;">

```cs
public class Post
{
  public string Title {get; set;}
  public string FullText {get; set;}

  public string ToHtml()
  {
    return Markdig.Markdown.ToHtml((string)value);
  }
}

```
</div>

</div>

---

# :thinking: What's wrong

- No code reuse
- Not unit testable 
- Tight coupling between UI and Business Logic
  + <span style="font-size: 1.5rem"> _Do I really need to touch the UI if I want to swap the HTTP call with something else?_ </span>
- A few more buttons and it would be difficult to understand

The code can be refactored in order to follow the **Model View ViewModel** pattern as Microsoft recommends.

---

# :thinking: What can be done?

- Architectural Patterns
- Design Patterns

---

<div class="center">

<!-- _footer: "![w:150px](assets/dotnet_bot.svg)" -->
# :bulb: Model View ViewModel
in .NET MAUI

</div>

---

- Architectural pattern
- Divides the architecture in **three** main components

![w:1920 h:250 center](assets/mvvm.drawio.svg)

- The **View** acts as a presentation layer and exposes the **ViewModel** properties.
- The **ViewModel** manipulates the **Model** and keeps the state of its data
- The **Model** describes the data we manipulate, often through POCO classes (_Plain Old C# Object_)

---

# :pen: Declarative UI

- MAUI allows to write the declarative part of the UI using a language known as **XAML**
- It is similar to XML and HTML
- This is implemented through **partial classes**

<div class="columns">

<div>

<div class="filename">

`MainWindow.xaml`

</div>

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="..."
             xmlns:x="..."
             x:Class="View.MainWindow">

    <VerticalStackLayout>
        <Label 
            Text="Loading..."
            VerticalOptions="Center" 
            HorizontalOptions="Center" />
    </VerticalStackLayout>

</ContentPage>
```

</div>

<div>

<div class="filename">

`MainWindow.xaml.cs`

</div>

```cs
namespace MauiAppExample.View;

public partial class MainWindow : ContentPage
{
    public MainWindow()
    {
        InitializeComponent();
    }
}

```

</div>
</div>

---

# :link: Data Binding 

- The ViewModel **must not** to depend on the View
- This allows developers to write the Business Logic without having to introduce unnecessary complexity
- The View **binds** to a specific View Model through a **binding engine**, which:
  - Allows the ViewModel to expose its properties to the View
  - Allows the View to update the ViewModel's properties and execute its commands

<br/>

Data binding happens at <u>Runtime</u> and does not require a <u>Compile Time</u> dependency between the two layers. 

---

<div class="filename">

`MainWindow.xaml`

</div>

```xml
<Label 
    Text="{Binding Message }"
    VerticalOptions="Center" 
    HorizontalOptions="Center" />
```

```xml
<Label 
    Text="{Binding Message, Converter = ..., FallbackValue = ..., Mode = ...}"
    VerticalOptions="Center" 
    HorizontalOptions="Center" />
```

##### Binding Mode can be

- One Way
- Two Way
- One Way to source
- One Time


---

# :mechanic: View Model

- It can be implemented as a normal C# class
- But it has to emit **an event** once a property has changed

<div class="filename">

`MainWindowViewmodel.cs`

</div>

```cs
public event PropertyChangedEventHandler PropertyChanged;

private string message; 

public string Message
{
  get => message;
  set
  {
    message = value;
    PropertyChanged?.Invoke(this, new(nameof(Message)));
  }
}
```

---

- Methods that need to be exposed to the UI can be wrapped inside the `Command` abstraction provided by MAUI

<div class="filename">

`MainWindowViewmodel.cs`

</div>

```cs
public Command SayHi { get; set; } = new Command(Callback);

private void Callback(object param)
{
  // command logic
}
```

#### Note

View-ViewModel communication can also be implemented without binding, by using.
  
- Publish/Subscribe protocols
- Messaging Handlers 
- ...

---

# :bricks: Model

- It can be intended in two different ways according to the requirements:
  - A **state content** (thinner View Model, logic resides in the model itself)
  - A **data access layer** (thicker View Model, the model is used to describe the data structure)

<br/>

<div class="filename">

`Post.cs`

</div>

```cs
public class Post
{
  public string Title {get; set;}
  public string FullText {get; set;}
}
```
---

<div class="center">

<!-- _footer: "![w:150px](assets/dotnet_bot.svg)" -->
# :bulb: Applying Design Patterns
##### in .NET MAUI

</div>

---

The usage of design patterns makes development easier and allows developer to handle complex lifecycles while keeping complexity under control.

<br/>

**Commonly used** design patterns are:

<br/>

<div class="columns">

<div>

- Builder
- Repository
- Factory
- Singleton
- Chain-of-Responsibility
- ...

</div>

<div>

- Service
- Observer
- Decorator
- Composite
- Dependency Injection

</div>

</div>

---

# :syringe: Dependency Injection

- The framework provides a dedicated library
- Allows to handle the internal dependencies in a **scalable** and **controllable** way

<br/>

### Idea 

1. The application builder registers service and classes to the **dependency container**, providing a concrete type, a lifecycle indication and, eventually, an **abstraction** 
2. At runtime, a dependency can be requested from the **container**
3. The latter will automatically figure out how to istantiate the object by looking at its constructor and providing the required services
4. An instance of the object is then returned

---

## :computer: Code Example
<div class="columns">
<div>
<div class="filename">

`AppBuilder.cs`
</div>

```csharp
service.AddSingleton<IAuth, Auth>();
service.AddTransient<IRepository, Repository>();
```
<div style="margin-top: 30px"></div>
<div class="filename">

`MyViewModel.cs`
</div>

```cs
{
  var repository = services.Get<IRepository>();
}
```
</div>
<div >
<div class="filename">

`Auth.cs`
</div>

```cs
// constructor

public Auth()
```
<hr/>
<div class="filename">

`Repository.cs`
</div>

```cs
// constructor

public Repository(IAuth auth)
```

</div>
</div>
</div>
<br/>

The dependency container detects the `IRepository` concrete implementation and **injects** the `IAuth` service in its constructor. Then the istance is returned.

---

<div class="center">

# :nerd_face: Project Sample

<div style="font-size: 1.7rem">

How are **MVVM**, **Dependency Injection** and **Design Patterns** applied in a real project?

</div>

<br/>

**Scenario**: &nbsp; _A .NET MAUI Application that allows to <u>post PAO slides</u>, with a <u>brief description</u> and a <u>title</u>, to an **external api** and <u>retrieve</u> them. Only <u>authenticated users</u> can access the content_.

</div>

