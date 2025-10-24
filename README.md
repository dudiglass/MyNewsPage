# MyNewsPage - עמוד החדשות שלי 📰

אפליקציית ווב ASP.NET Core מודרנית המציגה חדשות עדכניות מאתר ynet.co.il עם עיצוב מודרני ומשך לב.

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-0078D4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)

## ✨ תכונות עיקריות

- 📱 **עיצוב רספונסיבי** - נראה משובח בכל המכשירים
- 🌍 **חדשות בזמן אמת** - איסוף אוטומטי מ-ynet.co.il
- 🎨 **עיצוב מודרני** - גרדיינטים, צללים ואפקטים מודרנים
- 🚀 **אנימציות חלקות** - מעברים ואפקטים ב-CSS ו-JavaScript
- 🔄 **רענון אוטומטי** - העמוד מתעדכן כל 5 דקות
- 🎨 **תמיכה בעברית** - אתר מותאם לשפה העברית (RTL)

## 💻 טכנולוגיות

### Backend
- **ASP.NET Core 8.0** - פריימוורק הווב המודרני של מיקרוסופט
- **C#** - שפת תכנות מתקדמת וחזקה
- **HtmlAgilityPack** - טיפול ופיענוח HTML
- **HttpClient** - לבקשות HTTP אסינכרוניות

### Frontend  
- **Bootstrap 5** - עיצוב רספונסיבי מודרני
- **Font Awesome** - איקונים מקצועיים
- **Google Fonts (Heebo)** - פונט עברי יפה
- **Custom CSS/JS** - עיצוב ואנימציות מותאמים אישית

## 🚀 התקנה והרצה

### דרישות מקדימות
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- עורך טקסט (Visual Studio, VS Code, או כל עורך אחר)

### שלבי ההתקנה

1. **שיבוט הפרויקט**
```bash
git clone https://github.com/dudiglass/MyNewsPage.git
cd MyNewsPage
```

2. **שחזור חבילות נדרשות**
```bash
dotnet restore
```

3. **בניית הפרויקט**
```bash
dotnet build
```

4. **הרצת האפליקציה**
```bash
dotnet run
```

5. **פתיחת האתר**
   פתח את הדפדפן ועבור ל: `https://localhost:5001` או `http://localhost:5000`

## 📱 תמונות מסך

### מחשב שולחני
![Desktop View](https://via.placeholder.com/800x600/667eea/ffffff?text=תצוגה+שולחנית)

### מכשיר נייד
![Mobile View](https://via.placeholder.com/400x800/764ba2/ffffff?text=תצוגה+ניידת)

## 🏠 ארכיטקטורת הפרויקט

```
MyNewsPage/
│
├── Controllers/
│   └── HomeController.cs       # בקר ראשי לטיפול בבקשות
│
├── Models/
│   ├── NewsItem.cs            # מודל נתוני חדשה
│   └── ErrorViewModel.cs      # מודל טיפול בשגיאות
│
├── Services/
│   ├── INewsService.cs        # אינטרפייס שירות חדשות
│   └── YnetNewsService.cs     # מימוש איסוף חדשות מ-ynet
│
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml          # עמוד ראשי - תצוגת חדשות
│   │   └── Privacy.cshtml        # עמוד מדיניות פרטיות
│   │
│   └── Shared/
│       ├── _Layout.cshtml         # תבנית ראשית לאתר
│       └── _ViewStart.cshtml      # קובץ התחלת תצוגות
│
├── wwwroot/
│   ├── css/
│   │   └── site.css              # עיצוב מותאם מודרני
│   │
│   └── js/
│       └── site.js               # סקריפטים מותאמים
│
├── Program.cs                    # נקודת כניסה לאפליקציה
├── MyNewsPage.csproj             # קובץ פרויקט .NET
└── README.md                     # מסמך זה
```

## ⚙️ התאמה אישית

### שינוי מקור חדשות
לשינוי מקור החדשות, ערוך את הקובץ `Services/YnetNewsService.cs` ושנה את כתובת ה-URL.

### שינוי עיצוב
כל העיצוב מוגדר בקובץ `wwwroot/css/site.css` - תוכל לשנות צבעים, פונטים ואפקטים.

### הוספת תכונות
תוכל להוסיף:
- סינון חדשות לפי קטגוריות
- חיפוש בתוך החדשות
- שמירת חדשות מעדיפות
- התראות על שינויים

## 📊 ביצועים ומהירות

- **טעינת עמוד**: ~2-3 שניות (תלוי במהירות ynet)
- **רספונסיביות**: מותאם לכל גדלי מסך
- **נגישות**: תמיכה בקוראי מסך וניווט במקלדת

## 🚀 פריסה (Deployment)

### Azure App Service
```bash
# יצירת חבילה לפריסה
dotnet publish -c Release -o ./publish

# העלאה ל-Azure
az webapp up --sku F1 --name MyNewsPageApp
```

### Docker
```dockerfile
# דוגמה ל-Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "MyNewsPage.dll"]
```

## ❓ שאלות נפוצות

**ש: מדוע לא רואים חדשות?**
ת: בדוק את החיבור לאינטרנט ווודא ש-ynet.co.il זמין.

**ש: איך לשנות את תדירות הרענון?**
ת: ערוך את המשתנה `refreshTimer` בקובץ `wwwroot/js/site.js`.

**ש: האם האתר תומך במצב חשוך?**
ת: כן! האתר מתאים אוטומטית להעדפות המשתמש.

## 📞 תמיכה וקשר

- 🐛 **דיווח על באגים**: [פתח נושא חדש](https://github.com/dudiglass/MyNewsPage/issues)
- 💬 **דיונים**: [דף הדיונים](https://github.com/dudiglass/MyNewsPage/discussions)  
- 🔄 **בקשת מיזוג**: שלח Pull Request

## 📜 רישיון

פרויקט זה מופץ תחת רישיון MIT. ראה קובץ `LICENSE` לפרטים.

## 🙏 תודות

- **ynet.co.il** - מקור החדשות
- **Microsoft** - ASP.NET Core Framework
- **Bootstrap Team** - פריימוורק CSS
- **Font Awesome** - איקונים
- **Google Fonts** - פונט Heebo

---

<div align="center">
  <h3>🎆 נעשה עם ❤️ בישראל</h3>
  <p>פרויקט להדגמת יכולות ASP.NET Core ואיסוף נתונים מאתרי חדשות</p>
</div>