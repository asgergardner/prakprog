all:out.txt 
	cat $<

out.txt:main.exe pyintegrate.py
	mono $< > $@
	python3 pyintegrate.py >> $@

main.exe:main.cs integrator.dll
	mcs -t:exe -r:integrator.dll $<

integrator.dll:integrator.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.png
