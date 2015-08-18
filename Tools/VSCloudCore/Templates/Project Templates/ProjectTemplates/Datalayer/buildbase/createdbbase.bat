sqlmetal /server:localhost /namespace:$safeprojectname$ /database:$ProductDBName$ /code:"%~dp0\$ProductDBName$base.cs" /views /functions /sprocs /language:c# /context:$ProductDBName$base
