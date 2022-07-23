# xvp
XML validator program

# Usage
xvp -i(--input) [input files] -a(--against) ([xsd path] [targetnamespace])*

# Example
xvp --input test.xml --against test.xsd http://tempuri.org/test.xsd

Use multiple input files:
xvp --input test.xml test2.xml --against test.xsd http://tempuri.org/test.xsd

Use multiple xsd's:
xvp --input test.xml test2.xml --against test.xsd http://tempuri.org/test.xsd test2.xsd http://tempuri.org/test2.xsd

Note that target namespace and xsd path must be added in pairs and appear in the order: (path/to/xsd target-namespace)
