   M S B A M L   `   `   `  ????I  EProcatsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProcatsManager.WindowsProcatsManager.Windows  5   	   0    *ProcatsManager.Windows.WindowAuthorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProcatsManager.Windows     5   	     ? Title$)  #Курортный лесопарк??5   	   $	??440??5	   	   $	??350??5
   	   $	??440??5   	   $	??350??5   	   $??Comic Sans MS)?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Icon$ /Windows/logo.png??6.   .??5      ? ???	#FF92D050 ? ColumnDefinitions 5   
   ?? 5      ?? 5      $	??300 ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      $
??auto ?6   ?? 5      $??90 ?6   ?? 5      $??90 ?6   ?? 5      ?? 5      .+?5   
   ?? $??1??5       $??1??5!      $??35(?5"      $??Center=?5#      $??Center=?5$      $??Авторизация??5%      $??5q?5&      ?? 5)   
   $??1??5*      $??2??5+      $??25(?5,      $	??Top=?5-      $
??Left=?5.      $??E-mail:??5/      $??5q?50      ?? 52   
   -   5         ??Name$ tbxEmail??53      $??1??54      $??2??55      $??25(?56      $??40??57      $	??250??58      $??Bottom=?59      $
??Left=?5:      $??5q?5;      
???   ? ?? 	MaxLength$ 50??5>      ??5<      Z? 5>      ?? 5@   
   $??1??5A      $??3??5B      $??25(?5C      $	??Top=?5D      $
??Left=?5E      $??Пароль:??5F      $??5q?5G      ?? 5I   
   -   5        $ tbxPassword??5J      $??1??5K      $??3??5L      $??25(?5M      $??40??5N      $	??250??5O      $??Bottom=?5P      $
??Left=?5Q      $??5q?5R      
???   ?$ 50??5U      ??5S      Z? 5U      G? 5W   
   -   5         G?Name$ pbxPassword??5X      $??1??5Y      $??3??5Z      $??40??5[      $??25(?5\      $	??250??5]      $??Bottom=?5^      $
??Left=?5_      $??5q?5`      
???   ? G? 	MaxLength$ 50??5c      ??5a      Z? 5c      ?? 5e   
   -   5        	 ??Name$	 btPasswordView??5f      $??Bottom=?5g      $??2??5h      $
??Left=?5i      $??1??5j      $??3??5k      $??25(?5l      $??40??5m      $??40??5n      $??	258,5,5,5q?5o      
???   ???5s      ?? 5t      
 ?? ImageSource$!
 /Images/imgPassvordView.png??6   5v      ?? 5w   
   -   5        $	 btPasswordNotView??5x      $??Bottom=?5y      $??2??5z      $
??Left=?5{      $??1??5|      $??3??5}      $??25(?5~      $??40??5      $??40??5?      $??	258,5,5,5q?5?      
???   ???5?      ?? 5?      $$
 /Images/imgPassvordNotView.png??6   5?      ?? 5?   
   -   5        $	 btLogin??5?      $??
Войти??5?      $	??Top=?5?      $??Center=?5?      $??1??5?      $??4??5?      $??25(?5?      $??40??5?      $	??150??5?      $??10q?5?      
???   ????	#FF349C3D5?      5?      5?      