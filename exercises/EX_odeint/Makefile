all:odeint.png Makefile

odeint.png:out.txt odeint.gpi
	pyxplot odeint.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs vector.dll ode.dll 
	mcs -target:exe -reference:vector.dll -reference:ode.dll $< 

ode.dll:ode.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll:vector.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.txt 
