for path in src/*/project.json; do
  dirname="$(dirname "${path}")"
  dnu restore ${dirname}
  dnu build ${dirname} --configuration Release --out .\artifacts\testbin;
  dnu pack ${dirname} --configuration Release --out .\artifacts\packages;
done