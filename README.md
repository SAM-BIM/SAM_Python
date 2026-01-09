[![Build (Windows)](https://github.com/SAM-BIM/SAM_Python/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/SAM-BIM/SAM_Python/actions/workflows/build.yml)
[![Installer (latest)](https://img.shields.io/github/v/release/SAM-BIM/SAM_Deploy?label=installer)](https://github.com/SAM-BIM/SAM_Deploy/releases/latest)

# SAM_Python

<a href="https://github.com/SAM-BIM/SAM">
  <img src="https://github.com/SAM-BIM/SAM/blob/master/Grasshopper/SAM.Core.Grasshopper/Resources/SAM_Small.png"
       align="left" hspace="10" vspace="6">
</a>

**SAM_Python** is part of the **SAM (Sustainable Analytical Model) Toolkit** —  
an open-source collection of tools designed to help engineers create, manage,
and process analytical building models for energy and environmental analysis.

This repository provides **Python integration for SAM workflows**,
allowing SAM functionality to be accessed and extended using Python code.
It enables non–C# users to write custom logic and automation,
including execution from **Grasshopper Python components**.

The integration is intended to expose SAM analytical models and operations
to Python-based scripting environments while remaining compatible
with the SAM core libraries and related SAM-BIM modules.

Welcome — and let’s keep the open-source journey going. 🤝

---

## Features

- Access to SAM analytical models from Python
- Execution of SAM workflows via Python scripting
- Integration with Grasshopper Python components
- Support for custom logic without requiring C# development

---

## Resources
- 📘 **SAM Wiki:** https://github.com/SAM-BIM/SAM/wiki  
- 🧠 **SAM Core:** https://github.com/SAM-BIM/SAM  
- 🧰 **Installers:** https://github.com/SAM-BIM/SAM_Deploy  

---

## Installing

To install **SAM** using the Windows installer, download and run the  
[latest installer](https://github.com/SAM-BIM/SAM_Deploy/releases/latest).

Alternatively, you can build the toolkit from source using Visual Studio.  
See the main repository for details:  
👉 https://github.com/SAM-BIM/SAM

---

## Development notes

- Target framework: **.NET / C#**
- Python bindings follow SAM-BIM analytical modelling conventions
- New or modified `.cs` files must include the SPDX header from `COPYRIGHT_HEADER.txt`

---

## Licence

This repository is free software licensed under the  
**GNU Lesser General Public License v3.0 or later (LGPL-3.0-or-later)**.

Each contributor retains copyright to their respective contributions.  
The project history (Git) records authorship and provenance of all changes.

See:
- `LICENSE`
- `NOTICE`
- `COPYRIGHT_HEADER.txt`
