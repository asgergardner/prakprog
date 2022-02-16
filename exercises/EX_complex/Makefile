CMATHDIR = /mnt/c/Users/asger/prakprog/complex

out.txt : main.exe
	mono main.exe

main.exe : main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll main.cs

cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll
