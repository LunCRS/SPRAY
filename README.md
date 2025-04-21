# Ciallo ～(∠・ω< )⌒☆

<hr>

# Doc

初始操作：

### 1. gitea.trash0相关设置

到 [gitea](10.19.127.42:7920) 注册一个账号，将用户名告知主程，让他把你加进Collaborators

在用户设置中加入ssh key。具体操作如下

```bash
ssh-keygen -C "trash0gitea.你的邮箱" (引号内内容可以随意写)
```
如所有设置都直接回车：

打开 `C:/Users/你的用户名/.ssh/config`

写入：

```
Host trash0gitea
    HostName 10.19.127.42
    User git
    Port 7922
```
如有更改文件名，额外写入：
```
    IdentityFile 那个文件的完整目录
```
在gitea中加入ssh key，公钥为 `C:/Users/你的用户名/.ssh/id_ed25519.pub` 的内容。

### 2. clone项目

选一个合适的位置，在此处打开git bash
```git
git clone trash0gitea:aMbZfcaYn/2025CUSGA.git
```

### 3. 日常提交与同步

提交：
```git
git add .
git commit -m "commit标题信息" -m "commit补充信息" -m "补充信息" ...
git push origin main
```

同步：
```git
git pull
```
pull之前需要commit你的所有修改。

### 4. 其他操作

强制覆盖本地：
```git
git fetch --all
git reset --hard origin/main
```

强制覆盖远端（！危险！请咨询主程后再执行此操作）：
```git
git push origin main --force
```

