all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > $@

main.exe: main.cs passf.dll
	mcs -target:exe -reference:passf.dll $< 

passf.dll: passf.cs
	mcs -target:library -out:passf.dll $<

.PHONY:
clean: 
	rm *.dll *.txt *.exe
