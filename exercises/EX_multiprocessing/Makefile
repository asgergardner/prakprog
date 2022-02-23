all:out.txt
	cat $<

out.txt:main.exe
	mono $< > $@

main.exe:main.cs
	mcs -target:exe $<

.PHONY:
clean:
	rm out.* *.exe
