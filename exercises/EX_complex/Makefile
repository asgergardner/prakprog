out.txt : main.exe
	mono $<

main.exe : main.cs cmath.dll complex.dll
	mcs -target:exe -reference:cmath.dll,complex.dll $<

cmath.dll : cmath.cs complex.dll
	mcs -target:library -reference:complex.dll $<

complex.dll : complex.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.txt *.dll
