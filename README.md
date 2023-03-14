# How to contribute

At MindPort we want to thank you for being part of this community and contributing to the community repository of VR Builder, a place where you can share your custom behaviors, conditions and extensions.

### Table of Contents
1. [Getting Started](#getting-started)
1. [Installation](#installation)
1. [Content Guidelines](#content-guidelines)
1. [Obsolete Content](#obsolete-content)
1. [Submitting content](#submitting-content)
1. [Maintainers](#maintainers)
1. [Coding Conventions](#coding-conventions)
1. [Code of Conduct](#code-of-conduct)
1. [Legal](#legal)

## Getting Started
The easiest and simplest way to get started and try out VR Builder is by downloading the latest version from our [Git Repo](https://github.com/MindPort-GmbH/VR-Builder) or the [Unity Asset Store](https://assetstore.unity.com/packages/tools/visual-scripting/vr-builder-open-source-toolkit-for-vr-creation-201913).

Make sure to follow VR Builder [tutorials](https://www.mindport.co/vr-builder/tutorials) and read the [documentation](https://www.mindport.co/vr-builder/manual/online-documentation) for a deeper understanding of how the tool works.

Templates for behaviors and conditions can be found in this repo. Feel free to use them as a base to develop your own!

## Installation
Pull this repo in the `Assets` folder of a Unity project containing VR Builder, or create a submodule. The recommended path is `Assets/MindPort/VR Builder/Add-ons/Community`, but any path should work.

You are using this content at your own risk. MindPort will ensure that the main branch compiles with the latest version of VR Builder, but does not provide any guarantee that the content will keep working in future VR Builder versions.

## Content Guidelines
- If you are creating behaviors or conditions, you can refer to the commented templates provided in the `Source/Runtime/Behaviors` or `/Conditions` folder. These provide an example of how to organize the submission, as well as some guidance in coding a behavior or condition.
- Create subfolders for your content. Runtime code should go in the `Source/Runtime` folder (and subfolders where applicable), while editor code (e.g. menu items) should go in the `Source/Editor` folder.
- Document your contribution and provide contact information. The documentation should be included in the feature's main folder (e.g. where the behavior/condition's code is kept).
- Your code is based only on VR Builder core, and should not require any of the VR Builder add-ons to work.
- In case your code requires external packages to compile properly (e.g. a different XRIT version than current VR Builder, or a separate Unity asset), you can put it in zip archives while clearly documenting requirements and installation procedure.
- Content submitted is suitable for use in a professional or personal development pipeline.
- Your submission does not throw any errors or warnings which originate from package content after setup is complete. Handled exceptions are acceptable.
- Your contribution does not contain an excessive amount of spelling or grammar mistakes.
- Titles, categories, keywords, folders, and file names are a relevant representation of your product.
- Titles, descriptions, keywords, documentation, and code comments are in English. 
- The submission does not directly recreate a popular design, art style and aesthetic, and is not a compilation of found (copyrighted or not) content/products. 
- The submission is also not the direct result of public tutorials, unless significant value is added beyond the result of the tutorial.
- No aspect of your contribution promotes marketplaces, products or digital stores.
- Submissions may include demo scenes. 

## Obsolete Content
It can happen that older content is no longer compatible with VR Builder, due to updates in the main product. If a trivial update is required, maintainers will take care of it. If a more complex rework is needed, you will be notified so you can step in and solve the issue. Code that fails to compile will first be commented out and moved to an OBSOLETE folder, then deleted.

Note that maintainers will only address compile errors and don't perform any testing on community features - if the code still compiles but doesn't work as intended anymore due to external updates, it's up to the community to fix the issue or notify the feature is obsolete.

## Submitting Content
By default, this repository is protected, the only way to submit changes is by merging via [creating a pull request from a fork](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request-from-a-fork), this is only intending to provide the best quality and add a security layer, we could detect and prevent new bugs, breaking functionalities and avoid violations to [code convention](#coding-conventions).

See more about [Pull Requests](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/about-pull-requests) and [how to fork a repository](https://help.github.com/en/github/getting-started-with-github/fork-a-repo).

## Maintainers
Meet out maintainers:

| [<img alt="Marcello Tridenti" src="https://avatars.githubusercontent.com/u/24916383?v=4" width="110">](https://github.com/VaLiuM09) | 
| --- |
| [Marcello T.](mailto:marcello.tridenti@mindport.co) |

| [<img alt="Valeria Acevedo" src="https://avatars.githubusercontent.com/u/52221800?v=4" width="110">](https://github.com/bideckerz) | 
| --- |
| [Valeria A.](mailto:valeria.acevedo@mindport.co) |

Maintainers are responsible for this repository and its community.

## Coding Conventions
By encouraging coding conventions we ensure:

* The code has to have a consistent look, so that readers can focus on content, not layout.
* Enabling readers to understand the code more quickly by making assumptions based on previous experience.
* Facilitating copying, changing, and maintaining the code.
* Sticking to C# best practices.

We recommend following these [Coding Conventions](CODING_CONVENTIONS.md).

## Code of Conduct
By participating, you are expected to act and interact in ways that contribute to an open, welcoming, diverse, inclusive, and healthy community. and follow our Code of conduct. Please report unacceptable behavior.

Our Standards
Examples of behavior that contributes to a positive environment for our community include:

Demonstrating empathy and kindness toward other people
Being respectful of differing opinions, viewpoints, and experiences
Giving and gracefully accepting constructive feedback
Accepting responsibility and apologizing to those affected by our mistakes, and learning from the experience
Focusing on what is best not just for us as individuals, but for the overall community

Examples of unacceptable behavior include:

The use of sexualized language or imagery, and sexual attention or advances of any kind
Trolling, insulting or derogatory comments, and personal or political attacks
Public or private harassment
Publishing others’ private information, such as a physical or email address, without their explicit permission
Spam or other deceptive practices that take advantage of the community
Use of copyrighted assets without permission
Other conduct which could reasonably be considered inappropriate in a professional setting


Maintainers also have the right and responsibility to remove, edit, or reject comments, commits, code and other contributions that are not aligned to this Code of Conduct, and will communicate reasons for moderation decisions when appropriate.

## Legal

This repo is covered by the [MIT License](LICENSE.TXT).
By submitting content to this repo, you agree to it becoming open source.
