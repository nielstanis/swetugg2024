# Python on WASM / WASI

```python
import platform
platform.platform()
f = open("/etc/hosts", "r")
print(f.read())
```

## WasmTime

- `wasmtime run --dir . -- python.wasm`
- `wasmtime run --dir . --dir /etc -- python.wasm`