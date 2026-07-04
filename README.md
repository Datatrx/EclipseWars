# Eclipse Wars v3.5 FULL GAME - Tüm Sistemler

## 19 Sistem Dahil
1. EclipsePlayer - Ana karakter
2. GameManager - Oyun yönetimi
3. AntiCheat - Hile koruması
4. IAP System - Oyun içi satın alma
5. Mount System - 10 Binek
6. Wing System - 10 Kanat
7. Chat System - Global + Çeviri
8. Dungeon System - 5 Dungeon
9. Raid System - 3 Boss Raid
10. Guild Hall - Lonca evi
11. Mob System - 15 Mob + EXP
12. Test System - /test all
13. UIManager - UI yönetim

## Kurulum
1. Tüm dosyaları Unity Assets/ içine at
2. FishNet + Unity IAP paketlerini yükle
3. IAP_Config.json fiyatları düzenle
4. MobData.json mobları düzenle
5. Build > Android > APK

## Test Komutları
/test all - Tüm sistemleri test et
/spawn 9 - Kemik Ejderha çıkar
/exp 100000 - 100K EXP ver
/level 60 - Direkt Lv60 ol

## IAP Fiyat Düzenleme
Assets/Resources/IAP_Config.json aç:
"price": 29.99  ← Değiştir

Google Play'de aynı ID ile ürün oluştur.

## Mob Düzenleme
Assets/Resources/MobData.json aç:
"exp": 10000  ← EXP değiştir
"hp": 15000   ← Can değiştir

## Build Hazır
Cloud Build ile APK al. v3.5 = 19 sistem = Yayın hazır.
