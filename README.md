# Ciallo ～(∠・ω< )⌒☆

<hr>

# Commit
参照[https://www.conventionalcommits.org/en/v1.0.0/]

简单地：

```
feat(range of affected file, if those file can be described easily): implement some features, or do other things about features.
fix(range of affected file, if those file can be described easily): fix some problems.
style(range of affected file, if those file can be described easily): change about code style.
chore(range of affected file, if those file can be described easily): things don't related to code.

If cannot describe affected file, left there no "()".
If a commit is important, add "!" after scope. For example, feat!: do something.
```
For more examples, please see conventionalcommits.

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
在gitea中加入ssh key，公钥为 `C:/Users/你的用户名/.ssh/id_ed25519.pub` (如果前面有更改文件名，改为那个文件) 的内容。

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

撤销上一次commit和add，但保留本地修改：
```git
git reset --mixed HEAD^
git reset HEAD^
二者效果相同
```

撤销上一次commit，但保留add和本地修改：
```git
git reset --soft HEAD^
```

撤销上一次commit、add和本地修改：
```git
git reset --hard HEAD^
```

将修改并入上一次commit：
```git
git commit --amend
```
会打开一个文件，可以在文件内重新修改commit的信息
