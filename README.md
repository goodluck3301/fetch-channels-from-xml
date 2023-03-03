# FetchChannelsFromXML
- Fetch Channels From XML File


![image](https://user-images.githubusercontent.com/100533325/222794866-e6ced153-78c4-4998-ba56-1d83f965b0a5.png)


## XML File Must Contain This Tags & Atributes
```xml
<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE tv SYSTEM "https://iptvx.one/xmltv.dtd">

<tv generator-info-name="IptvX.one" generator-info-url="https://iptvx.one/">
  <channel id="no_epg">
    <display-name>
      NO EPG (заглушка)
    </display-name>
    <icon src="https://picon.ml/iptvxone.png"/>
  </channel>
  
  <programme start="20221204223500 +0300" stop="20221204233500 +0300" channel="zvyazda-by">
    <title lang="ru">«Нюрнбергский процесс. Вчера и завтра» Документальный фильм</title>
  </programme>
</tv>
```

## Channel Id Names Must Be This Format In File
```txt
zvyazda-by
tatarstan24
niki-kids
```

